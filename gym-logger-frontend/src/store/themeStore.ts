import { defineStore } from 'pinia'

export const useThemeStore = defineStore('theme', {
  state: () => ({
    currentTheme: localStorage.getItem('currentTheme') ?? 'theme-light',
    themes: ['theme-light', 'theme-dark']
  }),
  getters: {
    getCurrentTheme(): string {
      return this.currentTheme
    },
    getThemes(): string[] {
      return this.themes
    }
  },
  actions: {
    setCurrentTheme(theme: string): void {
      this.currentTheme = theme
      localStorage.setItem('currentTheme', theme)
    }
  }
})
