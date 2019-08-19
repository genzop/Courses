new Vue({
    el: '#app',
    data: {
        started: false,
        health: 100,
        monsterHealth: 100,
        attacks: []
    },
    computed: {
        showLog: function() {
            return this.started &&  this.attacks.length > 0;
        }
    },
    methods: {
        startGame: function() {
            this.started = true;
            this.health = 100;
            this.monsterHealth = 100;
            this.attacks = [];
        },
        attack: function(min, max) {
            var damage = this.calculateDamage(min, max);
            this.monsterHealth -= damage;
            this.attacks.unshift({ text: 'Player hits monster for ' + damage, isPlayer: true });
            
            if(this.monsterHealth < 1) {
                confirm("You win! Start a new game?") ? this.startGame() : this.started = false;
            } else {
                this.monsterAttack();
            }
        },            
        monsterAttack: function() {
            var damage = this.calculateDamage(5, 12);
            this.health -= damage;    
            this.attacks.unshift({ text: 'Monster hits player for ' + damage, isPlayer: false });
            
            if(this.health < 1) {
                confirm("You lost! :() Start a new game?") ? this.startGame() : this.started = false;
            }
        },
        heal: function() {
            this.health = this.health < 90 ? this.health + 10 : 100;
            this.attacks.unshift({ text: 'Player heals for 10', isPlayer: true });
            this.monsterAttack();
        },
        calculateDamage: function(min, max) {
            return Math.floor(Math.random() * (max - min + 1) + min);
        }
    }
});