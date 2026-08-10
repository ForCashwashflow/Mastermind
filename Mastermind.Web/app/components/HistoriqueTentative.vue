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