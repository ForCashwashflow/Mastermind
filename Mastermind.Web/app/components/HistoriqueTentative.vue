<script setup lang="ts">
import type { TentativeHistorique } from '../types/Mastermind'

defineProps<{
  tentatives: TentativeHistorique[]
}>()
</script>

<template>
  <section>
    <h2>Historique</h2>

    <div
      v-for="(tentative, index) in tentatives"
      :key="index"
    >
      <strong>
        {{ tentative.proposition.join(' - ') }}
      </strong>

      <p>Bien placés : {{ tentative.bienPlaces }}</p>
      <p>Mal placés : {{ tentative.malPlaces }}</p>

      <hr>
    </div>
  </section>
</template>

<style scoped>
section {
  margin-top: 28px;
}

div {
  padding: 14px 0;
}

strong {
  font-size: 17px;
}

p {
  margin: 6px 0;
}
</style>