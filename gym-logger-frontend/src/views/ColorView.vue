<template>
  <div>
    <div class="bg-page">Change themes</div>
    <div>Current theme: {{ store.getCurrentTheme }}</div>
    <div>
      <div class="bg-page">ColorView</div>
    </div>
    <div class="flex flex-wrap justify-center">
      <ColorRectangle class="bg-primary" />
      <ColorRectangle class="bg-primary-accent" />
      <ColorRectangle class="bg-panel" />
      <ColorRectangle class="bg-page" />
    </div>
    <select v-model="newTheme" @change="changeTheme(newTheme)">
      <option v-for="theme in store.getThemes" :key="theme" :value="theme">{{ theme }}</option>
    </select>
  </div>
</template>

<script setup lang="ts">
import { ref } from 'vue'
import { useThemeStore } from '../store/themeStore'
import ColorRectangle from '../components/ColorRectangle.vue'

const store = useThemeStore()
const newTheme = ref('')

const changeTheme = (theme: string) => {
  document.body.classList.remove(store.getCurrentTheme)
  store.setCurrentTheme(theme)
  document.body.classList.add(store.getCurrentTheme)
}
</script>

<style scoped>
@import '../styles/theme.css';
</style>
