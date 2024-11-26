<template>
  <li v-if="item.children" class="menu__item">
    <div class="menu__item-content">
      <span>{{ item.text }}</span>
      <BaseSidebarItem v-if="item.isOpen && item.children.length > 0" :items="item.children" />
    </div>
  </li>
</template>

<script setup lang="ts">
const props = defineProps({ item: Object })
</script>