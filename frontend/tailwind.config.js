/** @type {import('tailwindcss').Config} */
export default {
  content: ["./index.html", "./src/**/*.{js,ts,jsx,tsx}"],
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
            roboto: ['Roboto', 'sans-serif'],
          },
      },

  },
  plugins: [],
};

