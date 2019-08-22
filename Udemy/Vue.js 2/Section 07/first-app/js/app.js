var cmp = {
    template: '<p>Server Status: {{ status }} (<button @click="changeStatus">Change</button>)</p>',
    data: function() {
        return {
            status: 'Critical'
        } 
    },    
    methods: {
        changeStatus: function() {
            this.status = 'Normal';
        }
    }
};
 
new Vue({
    el: '#app',
    components: {
        'my-cmp': cmp
    }
});

new Vue({
    el: '#app2'    
});