/** @type {import('tailwindcss').Config} */
module.exports = {

    content: [
      "./src/**/*.{html,ts}",
    ],
    theme: {
      extend: {
        backgroundImage : {
          'custom' : "url('/assets/black-background.png')"
        }
      },
    },
    plugins: [ 
      require('daisyui')
    ],
  }

