<template>
  <div class="flex h-screen">
    <Sidebar />
    <main class="w-full p-8">
      <RouterView />
    </main>
  </div>
</template>

<script setup lang="ts">
import Sidebar from '@/components/sidebar/Sidebar.vue'
import { ref } from 'vue'

const isOpen = ref(false)

// You can add more functionality here if needed
</script>
