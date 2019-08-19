new Vue({
    el: '#app',
    data: {
        title: 'Hello World!',
        link: 'http://www.google.com',
        finishedLink: '<a href="http://www.google.com">Google</a>',
        counter: 0,
        x: 0,
        y: 0,
        name: 'Enzo',
        secondCounter: 0,
        attachRed: false,
        color: 'green',
        width: 100
    },
    methods: {
        sayHello: function() {
            this.title = 'Hello!';
            return this.title;
        },
        increase: function(event, step) {
            this.counter += step;
        },
        updateCoordinates: function(event) {
            this.x = event.clientX;
            this.y = event.clientY;
        },
        alertMe: function() {
            alert('Alert');
        },
        result: function() {
            return this.counter > 5 ? 'Greater 5' : 'Smaller 5';
        }
    },
    computed: {
        output: function() {
            return this.counter > 5 ? 'Greater 5' : 'Smaller 5';
        },
        divClasses: function() {
            return {
                red: this.attachRed,
                blue: !this.attachRed
            }
        },
        myStyle: function() {
            return {
                backgroundColor: this.color,
                width: this.width + 'px'
            }
        }
    },
    watch: {
        counter: function(value) {
            var vm = this;
            setTimeout(function() {
                vm.counter = 0;
            }, 2000);
        }
    }
})