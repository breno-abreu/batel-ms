<template>
  <main class="healthy-page bg-slate-100 p-6">
    <PrimeCard class="healthy-card shadow-xl">
      <template #title>
        <div class="healthy-title">
          <ActivityIcon :size="32" aria-hidden="true" />
          <span>Hello World</span>
        </div>
      </template>

      <template #content>
        <p class="eyebrow">
          {{ appName }}
        </p>
        <p class="description">
          Frontend do {{ appName }} rodando com Vite, Vue 3, Options API e TypeScript.
        </p>

        <div class="stack-list">
          <PrimeTag
            v-for="item in stack"
            :key="item"
            severity="info"
            :value="item"
          />
        </div>

        <div class="healthy-actions">
          <PrimeTag severity="success" :value="healthyLabel" />
          <PrimeButton label="PrimeVue ativo" icon="pi pi-check" rounded />
        </div>
      </template>
    </PrimeCard>
  </main>
</template>

<script lang="ts">
import { defineComponent } from 'vue'
import { ActivityIcon } from '@lucide/vue'
import PrimeButton from 'primevue/button'
import PrimeCard from 'primevue/card'
import PrimeTag from 'primevue/tag'
import { useAppStore } from '@/stores/appStore'

export default defineComponent({
  name: 'HomeView',
  components: {
    ActivityIcon,
    PrimeButton,
    PrimeCard,
    PrimeTag
  },
  computed: {
    appName(): string {
      return useAppStore().appName
    },
    healthyLabel(): string {
      return useAppStore().healthyLabel
    },
    stack(): string[] {
      return useAppStore().stack
    }
  }
})
</script>
