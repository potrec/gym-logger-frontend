<template>
  <div class="flex flex-col items-center bg-page-accent">
    {{ props.class }}
    <div :class="colorClass"></div>
  </div>
</template>

<script setup lang="ts">
import { computed, defineProps } from 'vue'

const props = defineProps<{
  class: {
    type: String
    required: true
    default: 'bg-primary'
  }
}>()

const colorClass = computed(() => props.class + ' rounded-lg w-24 h-24 mx-4 my-4')
</script>
