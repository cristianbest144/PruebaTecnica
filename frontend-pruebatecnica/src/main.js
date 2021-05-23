import { createApp } from 'vue'
import App from './App.vue'
import router from './router'

const app = createApp(App);

app.config.globalProperties.urlServices = "https://localhost:44337/api/";

app.use(router).mount('#app')
