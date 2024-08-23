<template>
  <div>
    <router-view />
  </div>
</template>

<script setup lang="ts">
import { onBeforeUnmount, onMounted } from 'vue'
import { useThemeStore } from './store/themeStore'

const store = useThemeStore()

onMounted(() => {
  document.body.classList.add(store.getCurrentTheme)
})

onBeforeUnmount(() => {
  document.body.classList.remove(store.getCurrentTheme)
})
</script>

<style scoped>
@import './styles/theme.css';
</style>
