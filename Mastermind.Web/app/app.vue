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
  max-width: 760px;
  margin: 60px auto;
  padding: 32px;
  font-family: Arial, sans-serif;
  background: #ffffff;
  border-radius: 16px;
  box-shadow: 0 10px 30px rgba(0, 0, 0, 0.08);
}

h1 {
  font-size: 36px;
  margin-bottom: 12px;
}

h2 {
  margin-top: 28px;
  margin-bottom: 14px;
  font-size: 24px;
}

p {
  line-height: 1.5;
}

button {
  padding: 10px 18px;
  border: none;
  border-radius: 8px;
  cursor: pointer;
  font-weight: 600;
  transition: transform 0.15s ease, box-shadow 0.15s ease;
}

button:hover {
  transform: translateY(-1px);
  box-shadow: 0 4px 10px rgba(0, 0, 0, 0.12);
}

button:disabled {
  cursor: not-allowed;
  opacity: 0.6;
}

section {
  margin-top: 24px;
}

hr {
  border: none;
  border-top: 1px solid #ddd;
  margin: 18px 0;
}
</style>