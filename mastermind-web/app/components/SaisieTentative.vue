<script setup lang="ts">
const proposition = ref<number[]>([1, 1, 1, 1])

const emit = defineEmits<{
  tentativeEnvoyee: [proposition: number[]]
}>()

function envoyerTentative() {
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
  gap: 10px;
  margin: 20px 0;
}

input {
  width: 50px;
  padding: 10px;
  text-align: center;
  font-size: 18px;
}
</style>