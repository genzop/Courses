 <template>
    <div>
        <app-server-status :key="server" v-for="server in 5"></app-server-status>
    </div>    
 </template>

 <script>
    import ServerStatus from './ServerStatus.vue'

    export default {
        components: {
            'app-server-status': ServerStatus
        }
    }
 </script>