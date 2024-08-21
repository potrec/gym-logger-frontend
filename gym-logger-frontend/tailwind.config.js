/** @type {import('tailwindcss').Config} */
export default {
  content: ['./src/**/*.{html,js,ts,vue,css}'],
  darkMode: 'class',
  theme: {
    extend: {
      colors: {
        primary: 'var(--primary-color)',
        'primary-accent': 'var(--primary-color-accent)',
        page: 'var(--page-background-color)',
        'page-accent': 'var(--page-background-color-accent)',
        panel: 'var(--panel-background-color)'
      }
    },
    variants: {
      extend: {}
    },
    plugins: [],
    corePlugins: {
      preflight: false
    }
  }
}
