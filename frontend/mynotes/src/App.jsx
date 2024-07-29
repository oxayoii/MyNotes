import { useEffect, useState } from 'react'
import './App.css'
import FormCreate from './components/FormCreate'
import Filters from './components/Filters'
import FormCard from './components/FormCard'
import { createNote, fetchNotes } from './service/notes'

function App() {
  const [notes, setNotes] = useState([]);
  const [filter, setFilter] = useState({
    search: "",
    sortItem: "date",
    sortOrder: "desc",
  });

  useEffect (() => {
    const fetchData = async() => {
      refreshNotes();
      console.log(notes);
    }
    fetchData();
  }, [filter])

  const onCreate = async (note) => {
    await createNote(note);
    refreshNotes();
  }
  const refreshNotes = async () => {
    let notes = await fetchNotes(filter);
    setNotes(notes);
  }
  return (
    <div className='all'>
      <div>
        <FormCreate onCreate={onCreate}/>
        <Filters filter={filter} setFilter={setFilter}/>
      </div>
      <ul>
        {notes.map((n) => (
          <li key={n.id}>
            <FormCard 
              id={n.id} 
              title={n.title} 
              description={n.description} 
              createAt={n.createAt} 
              onUpdate={refreshNotes}/>
          </li>
        ))}
      </ul>
    </div>
  )
}

export default App
