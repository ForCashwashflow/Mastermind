<script setup lang="ts">
const proposition = ref<number[]>([1, 1, 1, 1])
const erreur = ref<string | null>(null)

const emit = defineEmits<{
  tentativeEnvoyee: [proposition: number[]]
}>()

function envoyerTentative() {
  const propositionValide = proposition.value.every(
    chiffre =>
      Number.isInteger(chiffre) &&
      chiffre >= 1 &&
      chiffre <= 6
  )

  if (!propositionValide) {
    erreur.value = 'Chaque chiffre doit être compris entre 1 et 6.'
    return
  }

  erreur.value = null
  emit('tentativeEnvoyee', [...proposition.value])
}
</script>

<template>
  <section>
    <h2>Votre proposition</h2>

    <div class="proposition">
  <input
    v-for="(_, index) in proposition"
    :key="index"
    v-model.number="proposition[index]"
    type="number"
    min="1"
    max="6"
  >
</div>

<p v-if="erreur">
  {{ erreur }}
</p>

<button
  type="button"
  @click="envoyerTentative"
>
  Jouer
</button>
  </section>
</template>

<style scoped>
.proposition {
  display: flex;
  gap: 12px;
  margin: 18px 0;
  flex-wrap: wrap;
}

.proposition input {
  width: 64px;
  height: 52px;
  text-align: center;
  font-size: 22px;
  border: 1px solid #ccc;
  border-radius: 10px;
  outline: none;
}

.proposition input:focus {
  border-color: #555;
  box-shadow: 0 0 0 3px rgba(0, 0, 0, 0.06);
}

button {
  padding: 10px 20px;
  border: none;
  border-radius: 8px;
  cursor: pointer;
  font-weight: 600;
}
</style>