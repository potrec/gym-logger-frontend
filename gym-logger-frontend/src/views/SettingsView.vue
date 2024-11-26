<template>
  <div class="p-4">
    <h2 class="text-3xl font-bold mb-6">Integrations and Settings</h2>

    <Card>
      <CardHeader>
        <CardTitle>Sync Options</CardTitle>
      </CardHeader>
      <CardContent>
        <ToggleGroup v-model="syncOptions" optionLabel="label" optionValue="value" type="multiple">
          <ToggleGroupItem value="fitnessWatch" label="Fitness Watch" ><h3 class="text-1xl font-bold">Fitness watch</h3></ToggleGroupItem>
          <ToggleGroupItem value="runningApp" label="Running App" ><h3 class="text-1xl font-bold">Import data from other apps</h3></ToggleGroupItem>
        </ToggleGroup>
      </CardContent>
    </Card>

    <Card class="mt-6">
      <CardHeader>
        <CardTitle>Notification Settings</CardTitle>
      </CardHeader>
      <CardContent>
        <ToggleGroup v-model="notificationSettings" optionLabel="label" optionValue="value" type="multiple">
          <ToggleGroupItem value="email" label="Email" ><h3 class="text-1xl font-bold">Email</h3></ToggleGroupItem>
          <ToggleGroupItem value="push" label="Push Notifications" ><h3 class="text-1xl font-bold">Push Notifications</h3></ToggleGroupItem>
          <ToggleGroupItem value="sms" label="SMS" ><h3 class="text-1xl font-bold">SMS</h3></ToggleGroupItem>
        </ToggleGroup>
      </CardContent>
    </Card>

    <Card class="mt-6">
      <CardHeader>
        <CardTitle>Theme Settings</CardTitle>
      </CardHeader>
      <CardContent>
        <Select v-model="theme" :options="['Light', 'Dark','Contrast', 'System']" />
        <Select>
          <SelectTrigger class="w-[180px]">
            <SelectValue placeholder="Select a theme" />
          </SelectTrigger>
          <SelectContent>
            <SelectGroup>
              <SelectLabel>Themes</SelectLabel>
              <SelectItem value="light">
                Light
              </SelectItem>
              <SelectItem value="dark">
                Dark
              </SelectItem>
              <SelectItem value="contrast1">
                Yellow contrast with black text
              </SelectItem>
              <SelectItem value="contrast2">
                Dark contrast with white text
              </SelectItem>
              <SelectItem value="system">
                System
              </SelectItem>
            </SelectGroup>
          </SelectContent>
        </Select>
      </CardContent>
    </Card>

    <Card class="mt-6">
      <CardHeader>
        <CardTitle>Font Size Settings</CardTitle>
      </CardHeader>
      <CardContent>
        <Select v-model="selectedFontSize" :options="fontSizeOptions" />
        <Select>
          <SelectTrigger class="w-[180px]">
            <SelectValue placeholder="Select a font size" />
          </SelectTrigger>
          <SelectContent>
            <SelectGroup>
              <SelectLabel>Font Sizes</SelectLabel>
              <SelectItem value="small">Small</SelectItem>
              <SelectItem value="normal">Normal</SelectItem>
              <SelectItem value="big">Big</SelectItem>
            </SelectGroup>
          </SelectContent>
        </Select>
        <div class="text-center mt-4">
          <span :class="getFontSizeClass" class="font-bold">This text will change size</span>
        </div>
      </CardContent>
    </Card>
  </div>
</template>

<script setup lang="ts">
import { ref, computed } from 'vue'
import { Card, CardContent, CardHeader, CardTitle } from '@/components/ui/card'
import { Select, SelectContent, SelectGroup, SelectItem, SelectLabel, SelectTrigger, SelectValue } from '@/components/ui/select'

const selectedFontSize = ref('normal')

const fontSizeOptions = [
  { value: 'small', label: 'Small' },
  { value: 'normal', label: 'Normal' },
  { value: 'big', label: 'Big' }
]

const getFontSizeClass = computed(() => {
  switch(selectedFontSize.value) {
    case 'small':
      return 'text-sm'
    case 'normal':
      return 'text-base'
    case 'big':
      return 'text-lg'
    default:
      return ''
  }
})
</script>