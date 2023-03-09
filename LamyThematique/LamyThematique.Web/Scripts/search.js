var vueApp = new Vue({
    el: '#app',
    data: {
        model: model,
        selectedItems: selectedItems
    },
    methods: {
        onChangeEvent: function (index) {
            var lgr = this.model.selectFilters.length;
            debugger;
            if (index + 1 < lgr) {
                this.cleanChild(index + 1);
            } else {
                this.search();
            }
        },
        cleanChild: function (index) {
            debugger;
            var lgr = this.model.selectFilters.length;

            if (index + 1 <= lgr) {
                this.selectedItems[index] = 0;
                debugger;
                this.cleanChild(index + 1);
            }
        },
        search: function () {
            var self = this;
            $.ajax({
                url: "/api/searchbyfilter",
                contentType: 'application/json',
                data: getFilters(),
                type: 'POST',
                success: function (data) {
                    debugger;
                    self.model.items = data;
                }
            });
        }
    },
    computed: {
        // un accesseur (getter) calculé
        reversedMessage: function () {
            // `this` pointe sur l'instance vm
            return this.message.split('').reverse().join('')
        }
    }
});


function getFilters() {
    var checks = new Array();

    checkboxes.forEach((x) => {
        if (x.checked === true) {
            checks.push(x.id);
        }
    });

    return JSON.stringify({
        'filtreThemes': selectedItems,
        'filtreTypes': checks
    });
}