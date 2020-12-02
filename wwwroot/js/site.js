new Vue({
    el: "#root",
    
    data: {
        model: '{ "name" : "Bob Smith", "address" : "1 Smith St, Smithville", "orderId" : "123455", "total" : 23435.34, "items" : [ { "name" : "1kg carrots", "quantity" : 1, "total" : 4.99 }, { "name" : "2L Milk", "quantity" : 1, "total" : 3.5 } ] }',
        template: "Dear {{ model.name }},\n" +
            "\n" +
            "Your order, {{ model.orderId}}, is now ready to be collected.\n" +
            "\n" +
            "Your order shall be delivered to {{ model.address }}.  If you need it delivered to another location, please contact as ASAP.\n" +
            "\n" +
            "Order: {{ model.orderId}}\n" +
            "Total: {{ model.total | math.format \"c\" \"en-US\" }}\n" +
            "\n" +
            "Items:\n" +
            "------\n" +
            "{{- for item in model.items }}\n" +
            " * {{ item.quantity }} x {{ item.name }} - {{ item.total | math.format \"c\" \"en-US\" }}\n" +
            "{{- end }}\n" +
            "\n" +
            "Thanks,\n" +
            "BuyFromUs",
        output: "This is the text value.",
        loading: false
    },

    methods: {
        generate() {
            this.loading = true;
            axios.post('/generate', {
                model: this.model,
                template: this.template,
                output: this.output
            }).then(response => {
                this.output = response.data.output;
            }).catch(response => {
                alert(response);
            }).finally(x => {
                this.loading = false;
            });
        }
    },
    
    beforeMount() {
        this.generate();
    }
});
