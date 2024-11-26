<script setup lang="ts">
import { ref } from 'vue'
import { Card, CardContent, CardHeader, CardTitle } from '@/components/ui/card'

const caloriesBurned = ref('2500')
const caloriesConsumed = ref('2000')
const exercisesPerformed = ref('5')
const goals = ref('Lose 5kg in 3 months')

const recentMeals = ref(['Breakfast', 'Lunch', 'Dinner'])
const recentWorkouts = ref(['Push-ups', 'Squats', 'Running'])

</script>

<template>
  <div class="p-4">
    <h2 class="text-3xl font-bold mb-6">Dashboard</h2>

    <Card class="mb-6">
      <CardHeader>
        <CardTitle>Daily Summary</CardTitle>
      </CardHeader>
      <CardContent class="grid grid-cols-2 gap-4">
        <div>
          <p class="font-semibold">Calories Burned</p>
          <p>{{ caloriesBurned }}</p>
        </div>
        <div>
          <p class="font-semibold">Calories Consumed</p>
          <p>{{ caloriesConsumed }}</p>
        </div>
        <div>
          <p class="font-semibold">Exercises Performed</p>
          <p>{{ exercisesPerformed }}</p>
        </div>
        <div>
          <p class="font-semibold">Goals</p>
          <p>{{ goals }}</p>
        </div>
      </CardContent>
    </Card>

    <Card class="mb-6">
      <CardHeader>
        <CardTitle>Recent Meals</CardTitle>
      </CardHeader>
      <CardContent v-if="recentMeals.length > 0" class="list-disc pl-5">
        <li v-for="(meal, index) in recentMeals" :key="index">{{ meal }}</li>
      </CardContent>
      <CardContent v-else>No recent meals.</CardContent>
    </Card>

    <Card class="mb-6">
      <CardHeader>
        <CardTitle>Recent Workouts</CardTitle>
      </CardHeader>
      <CardContent v-if="recentWorkouts.length > 0" class="list-disc pl-5">
        <li v-for="(workout, index) in recentWorkouts" :key="index">{{ workout }}</li>
      </CardContent>
      <CardContent v-else>No recent workouts.</CardContent>
    </Card>

    <Card>
      <CardHeader>
        <CardTitle>Recommended Goals</CardTitle>
      </CardHeader>
      <CardContent>
        <p>Y4:0</p>
      </CardContent>
    </Card>
  </div>
</template>

<style scoped>
.card-content {
  @apply text-sm;
}

.card-title {
  @apply font-semibold;
}
</style>
