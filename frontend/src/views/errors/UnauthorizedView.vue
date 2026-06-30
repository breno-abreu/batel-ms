<template>
  <main class="error-page bg-slate-100 p-6">
    <PrimeCard class="error-card shadow-xl">
      <template #title>
        <div class="error-title">
          <ShieldAlertIcon :size="40" aria-hidden="true" />
          <span>401</span>
        </div>
      </template>

      <template #content>
        <p class="eyebrow">
          Acesso não autorizado
        </p>
        <p class="description">
          Você precisa estar autenticado ou possuir permissão para acessar este recurso.
        </p>

        <PrimeButton label="Voltar para o início" icon="pi pi-home" rounded @click="goHome" />
      </template>
    </PrimeCard>
  </main>
</template>

<script lang="ts">
import { defineComponent } from 'vue'
import { ShieldAlertIcon } from '@lucide/vue'
import PrimeButton from 'primevue/button'
import PrimeCard from 'primevue/card'

export default defineComponent({
  name: 'UnauthorizedView',
  components: {
    PrimeButton,
    PrimeCard,
    ShieldAlertIcon
  },
  methods: {
    goHome(): void {
      this.$router.push({ name: 'home' })
    }
  }
})
</script>
