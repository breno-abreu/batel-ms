<template>
  <main class="error-page bg-slate-100 p-6">
    <PrimeCard class="error-card shadow-xl">
      <template #title>
        <div class="error-title">
          <SearchXIcon :size="40" aria-hidden="true" />
          <span>404</span>
        </div>
      </template>

      <template #content>
        <p class="eyebrow">
          Página não encontrada
        </p>
        <p class="description">
          O endereço solicitado não existe ou o recurso retornado pela API não foi localizado.
        </p>

        <PrimeButton label="Voltar para o início" icon="pi pi-home" rounded @click="goHome" />
      </template>
    </PrimeCard>
  </main>
</template>

<script lang="ts">
import { defineComponent } from 'vue'
import { SearchXIcon } from '@lucide/vue'
import PrimeButton from 'primevue/button'
import PrimeCard from 'primevue/card'

export default defineComponent({
  name: 'NotFoundView',
  components: {
    PrimeButton,
    PrimeCard,
    SearchXIcon
  },
  methods: {
    goHome(): void {
      this.$router.push({ name: 'home' })
    }
  }
})
</script>
