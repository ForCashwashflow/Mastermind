<script setup lang="ts">
import type { ReponseTentative } from '../types/Mastermind'

defineProps<{
  resultat: ReponseTentative
}>()
</script>

<template>
  <section>
    <h2>Résultat</h2>

    <p>Bien placés : {{ resultat.bienPlaces }}</p>
    <p>Mal placés : {{ resultat.malPlaces }}</p>
    <p>Tentatives restantes : {{ resultat.tentativesRestantes }}</p>
    <p>État : {{ resultat.etat }}</p>
  </section>
</template>

<style scoped>
section {
  margin-top: 28px;
  padding: 20px;
  border-radius: 12px;
  background: #f7f7f7;
}

p {
  margin: 8px 0;
}
</style>