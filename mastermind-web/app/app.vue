<script setup lang="ts">
import type {
  ReponsePartie,
  ReponseTentative
} from './types/Mastermind'

const idPartie = ref<string | null>(null)
const resultat = ref<ReponseTentative | null>(null)
const erreur = ref<string | null>(null)
const partie = ref<ReponsePartie | null>(null)

  
function enregistrerPartie(id: string) {
  idPartie.value = id
  resultat.value = null
  partie.value = null
  erreur.value = null
}
async function recevoirTentative(proposition: number[]) {
  if (!idPartie.value) {
    return
  }

  erreur.value = null

  try {
    resultat.value = await $fetch<ReponseTentative>(
      `http://localhost:5054/api/jeu/${idPartie.value}/tentative`,
      {
        method: 'POST',
        body: {
          proposition
        }
      }
    )

    await chargerPartie()
  } catch (e: any) {
  console.error(e)

  erreur.value =
    e?.data?.message ??
    'Erreur lors de la tentative.'
}
}
async function chargerPartie() {
  if (!idPartie.value) {
    return
  }

  partie.value = await $fetch<ReponsePartie>(
    `http://localhost:5054/api/jeu/${idPartie.value}`
  )
}
</script>

<template>
  <main>
    <h1>Mastermind</h1>

    <p>
      Devinez le code secret composé de 4 chiffres entre 1 et 6.
    </p>

    <NouvellePartie @partie-creee="enregistrerPartie" />

    <p v-if="idPartie">
      Partie créée : {{ idPartie }}
    </p>

    <SaisieTentative
  v-if="idPartie && (!partie || partie.etat === 'EnCours')"
  @tentative-envoyee="recevoirTentative"
/>
<p v-if="partie?.etat === 'Gagnee'">
  Bravo, vous avez trouvé le code secret !
</p>

<p v-if="partie?.etat === 'Perdue'">
  Partie terminée : vous avez utilisé vos 10 tentatives.
</p>

<ResultatTentative
  v-if="resultat"
  :resultat="resultat"
/>

<HistoriqueTentative
  v-if="partie && partie.tentatives.length > 0"
  :tentatives="partie.tentatives"
/>

<p v-if="erreur">
  {{ erreur }}
</p>
  </main>
</template>

<style scoped>
main {
  max-width: 700px;
  margin: 60px auto;
  padding: 24px;
  font-family: Arial, sans-serif;
}
</style>