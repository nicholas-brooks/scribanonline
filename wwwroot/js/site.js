new Vue({
    el: "#root",

    data: {
        model: "{\n    \"value\" : \"text value\"\n}",
        template: "This is the {{ model.value }}.",
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
            })
            .catch(response => {
                alert(response);
            })
            .finally(x => {
                this.loading = false;
            });    
        }
    }
});