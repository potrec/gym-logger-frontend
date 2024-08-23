<template>
  <div class="flex flex-col">
    <label class="font-light" :for="id">{{ label }}</label>
    <input
      class="bg-page-accent mt-1 pl-2 border-b-2 border-red-500 outline-none"
      :type="type"
      :id="id"
    />
  </div>
</template>

<script setup lang="ts">
import { defineProps } from 'vue'

const props = defineProps<{
  label: string
  type: string
  id: string
}>()

const { label, type, id } = props
</script>

<style scoped></style>
