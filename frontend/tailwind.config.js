/** @type {import('tailwindcss').Config} */
module.exports = {
  content: [
    "./src/**/*.{js,jsx,ts,tsx}",
  ],
  theme: {
      
      colors: {
          'white': '#FFFFFF',
          'black': '#242424',
          'grey': '#F3F3F3',
          'dark-grey': '#5A5A5A',
          'red': '#FF4E4E',
          'transparent': 'transparent',
          'dodger-blue': '#2196F3',
          'purple': '#8B46FF',
          'teal': '#28DBD0',
          'navy': '#002160',
          'dark-cyan': '#008B8B',
          'smoke': '#848884',
          'coral-pink': '#F88379',
          'royal-blue': '#5B84FF',
          'alice-blue': '#F0F8FF',
          'royal-blue-transparent': 'rgba(91, 132, 255, 0.08)'
      },

    fontSize: {
        'sm': '12px',
        'base': '14px',
        'xl': '16px',
        '2xl': '20px',
        '3xl': '28px',
        '4xl': '38px',
        '5xl': '50px',
        inherit: 'inherit'
    },

      extend: {
        fontFamily: {
          inter: ["'Inter'", "sans-serif"],
          gelasio: ["'Gelasio'", "serif"],
          roboto: ["Roboto, Helvetica Neue, Helvetica, Arial, sans-serif"]
        },
        flex: {
          '4': '4 4 0%',
          '2': '2 2 0%',
        },
        keyframes: {
          'expand': {
            '0%': { maxHeight: '0', opacity: '0' },
            '100%': { maxHeight: '500px', opacity: '1' }, // Adjust maxHeight as necessary
          },
          'collapse': {
            '0%': { maxHeight: '500px', opacity: '1' }, // Adjust maxHeight as necessary
            '100%': { maxHeight: '0', opacity: '0' },
          }
        },
        animation: {
          'expand': 'expand 300ms ease-out forwards',
          'collapse': 'collapse 300ms ease-in forwards',
        }
      },

  },

  plugins: [],
}

