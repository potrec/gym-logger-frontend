<script setup lang="ts">
import { ref } from 'vue'
import { DialogFooter } from '@/components/ui/dialog'
import { Card, CardContent, CardFooter, CardHeader, CardTitle } from '@/components/ui/card'
import { TableBody, TableCell, TableRow } from '@/components/ui/table'
import { Button } from '@/components/ui/button'
const workoutSchedule = ref([
  {
    name: 'Chest Day',
    date: '26-11-2024',
    exercises: ['Bench Press', 'Push-ups', 'Dumbbell Flyes']
  },
  {
    name: 'Back Day',
    date: '27-11-2024',
    exercises: ['Deadlifts', 'Pull-ups', 'Bent-over Rows']
  },
  {
    name: 'Leg Day',
    date: '28-11-2024',
    exercises: ['Squats', 'Lunges', 'Leg Press']
  }
])
const workoutGoal = ref('')
const selectedMuscleGroup = ref('')

const workoutHistory = ref([
  {
    date: '25-11-2024',
    exercises: ['Bench Press', 'Push-ups', 'Dumbbell Flyes'],
    weight: 50,
    reps: 10
  },
  {
    date: '24-11-2024',
    exercises: ['Deadlifts', 'Pull-ups', 'Bent-over Rows'],
    weight: 60,
    reps: 8
  },
  {
    date: '23-11-2024',
    exercises: ['Squats', 'Lunges', 'Leg Press'],
    weight: 70,
    reps: 12
  }
])

const showWorkoutGenerator = ref(false)

const expandDetails = (index: number) => {
  console.log('Expand details for workout:', workoutSchedule.value[index])
}

const editWorkout = (index: number) => {
  console.log('Edit workout:', workoutSchedule.value[index])
}

const deleteWorkout = (index: number) => {
  console.log('Delete workout:', workoutSchedule.value[index])
}

const generateWorkoutPlan = () => {
  console.log('Generate workout plan with goal:', workoutGoal.value, 'and muscle group:', selectedMuscleGroup.value)
}

</script>

<template>
  <div class="p-4">
    <h2 class="text-3xl font-bold mb-6">Workout Schedule</h2>

    <div class="grid grid-cols-1 md:grid-cols-3 gap-4">
      <Card v-for="(workout, index) in workoutSchedule" :key="index" class="col-span-1">
        <CardHeader>
          <CardTitle>{{ workout.name }}</CardTitle>
          <CardDescription>{{ workout.date }}</CardDescription>
        </CardHeader>
        <CardContent>
          <p>{{ workout.exercises.join(', ') }}</p>
          <Button variant="outline" @click="expandDetails(index)">Expand Details</Button>
        </CardContent>
        <CardFooter class="space-x-2">
          <Button variant="outline" @click="editWorkout(index)">Edit</Button>
          <Button variant="outline" @click="deleteWorkout(index)">Delete</Button>
        </CardFooter>
      </Card>
    </div>

    <Dialog v-model:open="showWorkoutGenerator">
      <DialogContent>
        <DialogTitle>Customize Your Workout Plan</DialogTitle>
        <DialogContent>
          <div class="grid gap-4">
            <Input placeholder="Enter your goal (e.g., weight loss, strength gain)" v-model="workoutGoal" />
            <Select placeholder="Choose muscle group" v-model="selectedMuscleGroup">
              <Option value="chest">Chest</Option>
              <Option value="back">Back</Option>
            </Select>
          </div>
        </DialogContent>
        <DialogFooter>
          <Button @click="generateWorkoutPlan">Generate Plan</Button>
        </DialogFooter>
      </DialogContent>
    </Dialog>

    <Card>
      <CardHeader>
        <CardTitle>Workout History</CardTitle>
      </CardHeader>
      <CardContent>
        <Table>
          <TableBody>
            <TableRow v-for="(historyItem, index) in workoutHistory" :key="index">
              <TableCell>{{ historyItem.date }}</TableCell>
              <TableCell>{{ historyItem.exercises.join(', ') }}</TableCell>
              <TableCell>{{ historyItem.weight }} kg</TableCell>
              <TableCell>{{ historyItem.reps }} reps</TableCell>
            </TableRow>
          </TableBody>
        </Table>
      </CardContent>
    </Card>
  </div>
</template>


