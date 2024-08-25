<template>
  <div class="flex flex-col my-2">
    <label class="font-light" :for="id">{{ label }}</label>
    <div class="relative bg-page-accent mt-1 border-b-2 border-red-500">
      <font-awesome-icon
        :icon="icon"
        class="absolute left-2 top-1/2 transform -translate-y-1/2 text-gray-500"
      />
      <input class="w-full pl-8 outline-none bg-transparent" :type="type" :id="id" />
    </div>
  </div>
</template>

<script setup lang="ts">
import { defineProps } from 'vue'

const props = defineProps<{
  label: string
  type: string
  id: string
  icon: string[]
}>()

const { label, type, id, icon } = props
</script>

<style scoped></style>
