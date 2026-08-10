<script setup lang="ts">
import type { ReponseCreationPartie } from '../types/Mastermind'

const emit = defineEmits<{
  partieCreee: [id: string]
}>()

const chargement = ref(false)
const erreur = ref<string | null>(null)

async function creerPartie() {
  chargement.value = true
  erreur.value = null

  try {
    const reponse = await $fetch<ReponseCreationPartie>(
      'http://localhost:5054/api/jeu',
      {
        method: 'POST'
      }
    )

    emit('partieCreee', reponse.id)
  } catch (e) {
    console.error(e)
    erreur.value = 'Impossible de créer la partie.'
  } finally {
    chargement.value = false
  }
}
</script>

<template>
  <section>
    <button
      type="button"
      :disabled="chargement"
      @click="creerPartie"
    >
      {{ chargement ? 'Création...' : 'Nouvelle partie' }}
    </button>

    <p v-if="erreur">
      {{ erreur }}
    </p>
  </section>
</template>