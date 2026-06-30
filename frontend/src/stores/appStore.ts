import { defineStore } from 'pinia'

export const useAppStore = defineStore('app', {
  state: () => ({
    appName: 'Batel MS',
    statusMessage: 'Healthy',
    stack: ['Vite', 'Vue 3', 'Options API', 'TypeScript', 'PrimeVue', 'Tailwind CSS', 'Pinia']
  }),
  getters: {
    healthyLabel: (state) => `${state.appName} ${state.statusMessage}`
  }
})
