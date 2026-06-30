import { createApp } from 'vue'
import PrimeVue from 'primevue/config'
import Lara from '@primeuix/themes/lara'
import { createPinia } from 'pinia'
import 'primeicons/primeicons.css'
import '@/style.css'
import App from '@/App.vue'
import router from '@/router'

const app = createApp(App)

app.use(createPinia())
app.use(router)
app.use(PrimeVue, {
  theme: {
    preset: Lara
  }
})

app.mount('#app')
