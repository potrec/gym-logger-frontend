<script setup lang="ts">
import {
  Table,
  TableBody,
  TableCaption,
  TableCell,
  TableHead,
  TableHeader,
  TableRow,
} from '@/components/ui/table'
import { Button } from '@/components/ui/button'
import {
  Dialog,
  DialogContent,
  DialogDescription,
  DialogFooter,
  DialogHeader,
  DialogTitle,
  DialogTrigger,
} from '@/components/ui/dialog'
import { Input } from '@/components/ui/input'
import { Label } from '@/components/ui/label'
import { computed, ref } from 'vue'

const dailyMeals = ref([
  {
    meal: 'Breakfast',
    time: '08:00',
    food: [
      { name: 'Oatmeal', calories: '150', protein: '5g', carbs: '25g', fats: '2g' },
      { name: 'Banana', calories: '100', protein: '1g', carbs: '27g', fats: '0g' }
    ]
  },
  {
    meal: 'Lunch',
    time: '12:00',
    food: [
      { name: 'Grilled Chicken Breast', calories: '140', protein: '26g', carbs: '0g', fats: '3g' },
      { name: 'Quinoa', calories: '150', protein: '4g', carbs: '30g', fats: '2g' },
      { name: 'Broccoli', calories: '55', protein: '2g', carbs: '11g', fats: '0g' }
    ]
  },
  {
    meal: 'Dinner',
    time: '18:00',
    food: [
      { name: 'Salmon', calories: '200', protein: '20g', carbs: '0g', fats: '12g' },
      { name: 'Brown Rice', calories: '150', protein: '3g', carbs: '30g', fats: '1g' },
      { name: 'Asparagus', calories: '20', protein: '2g', carbs: '4g', fats: '0g' }
    ]
  },
  {
    meal: 'Snack',
    time: '15:00',
    food: [
      { name : 'None', calories: '0', protein: '0', carbs: '0', fats: '0' }
    ]
  }
])

const showFoodFinder = ref(false)
const selectedMealIndex = ref(-1)

// Function to update daily meals based on user input
const updateDailyMeals = () => {
  const updatedMeals = [...dailyMeals.value]
  if (selectedMealIndex.value >= 0 && selectedMealIndex.value < updatedMeals.length) {
    updatedMeals[selectedMealIndex.value].food.push({
      name: '',
      calories: '',
      protein: '',
      carbs: '',
      fats: ''
    })
  }
  dailyMeals.value = updatedMeals
}

// Calculate total values
const totalCalories = computed(() =>
  dailyMeals.value.reduce((total, meal) => total + calculateTotalCalories(meal), 0)
)
const totalProtein = computed(() =>
  dailyMeals.value.reduce((total, meal) => total + meal.food.reduce((t, f) => t + parseInt(f.protein) || 0, 0), 0)
)

const totalCarbs = computed(() =>
  dailyMeals.value.reduce((total, meal) => total + meal.food.reduce((t, f) => t + parseInt(f.carbs) || 0, 0), 0)
)

const totalFats = computed(() =>
  dailyMeals.value.reduce((total, meal) => total + meal.food.reduce((t, f) => t + parseInt(f.fats) || 0, 0), 0)
)

const mealName = ref('')
const time = ref('')

const addNewMeal = () => {
  if (mealName.value && time.value) {
    dailyMeals.value.push({
      meal: mealName.value,
      time: time.value,
      food: []
    })
    showFoodFinder.value = false
    mealName.value = ''
    time.value = ''
  }
}

const calculateTotalCalories = (meal) =>
  meal.food.reduce((total, food) => total + parseInt(food.calories) || 0, 0)
</script>

<template>
  <div class="p-4">
    <h2 class="text-3xl font-bold mb-6">Diet Planning</h2>

    <Table>
      <TableCaption>Daily Meal Plan</TableCaption>
      <TableHeader>
        <TableRow>
          <TableHead class="w-[100px]">Meal</TableHead>
          <TableHead>Time</TableHead>
          <TableHead>Food</TableHead>
          <TableHead>Calories</TableHead>
        </TableRow>
      </TableHeader>
      <TableBody>
        <TableRow v-for="(meal, index) in dailyMeals" :key="index">
          <TableCell class="font-medium">{{ meal.meal }}</TableCell>
          <TableCell>{{ meal.time }}</TableCell>
          <TableCell v-if="meal.food.length">
            {{ meal.food.map(f => f.name).join(', ') }}
          </TableCell>
          <TableCell class="text-right">{{ calculateTotalCalories(meal) }}</TableCell>
        </TableRow>
      </TableBody>
    </Table>

    <Card class="mb-6">
      <CardHeader>
      </CardHeader>
      <CardContent>
        <div class="grid grid-cols-2 gap-4">
          <div>
            <Label for="calories" class="text-right">
              Total Calories:
            </Label>
            <Input id="calories" type="number" v-model="totalCalories" readonly />
          </div>
          <div>
            <Label for="protein" class="text-right">
              Total Protein:
            </Label>
            <Input id="protein" type="number" v-model="totalProtein" readonly />
          </div>
          <div>
            <Label for="carbs" class="text-right">
              Total Carbohydrates:
            </Label>
            <Input id="carbs" type="number" v-model="totalCarbs" readonly />
          </div>
          <div>
            <Label for="fats" class="text-right">
              Total Fats:
            </Label>
            <Input id="fats" type="number" v-model="totalFats" readonly />
          </div>
        </div>
      </CardContent>
    </Card>

    <div class="flex justify-center mt-4">
      <Button @click="showFoodFinder = true">Add New Meal</Button>
    </div>
    <Dialog v-model:open="showFoodFinder">
      <DialogContent class="sm:max-w-[425px] mx-auto">
        <DialogHeader>
          <DialogTitle>Add New Meal</DialogTitle>
          <DialogDescription>
            Add a new meal to your daily plan...
          </DialogDescription>
        </DialogHeader>
        <div class="grid gap-4 py-4">
          <Input placeholder="Meal name" v-model="mealName" />
          <Input placeholder="Time" v-model="time" />
          <Button @click="addNewMeal">Add Meal</Button>
        </div>
      </DialogContent>
    </Dialog>
  </div>
</template>
