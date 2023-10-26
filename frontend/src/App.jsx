import { useState } from 'react'
import { Person } from './pages/Person';
import './App.css'
function App() {
  return (
    <main className='w3-margin'>
      <h4>All persons CRUD</h4>
      <Person/>
    </main>
  )
}

export default App
