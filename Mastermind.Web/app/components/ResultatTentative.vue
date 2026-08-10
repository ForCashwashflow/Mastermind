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