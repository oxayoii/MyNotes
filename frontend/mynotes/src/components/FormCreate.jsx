import { Button, Input, Textarea } from "@chakra-ui/react";
import { useState } from "react";

export default function FormCreate ({onCreate}) {
  const [note, setNote] = useState(null);

  const onSubmit = (e) => {
    e.preventDefault;
    setNote(null);
    onCreate(note);
  }
    return (
        <form className='formCreate' onSubmit={onSubmit}>
          <h3>СОЗДАТЬ ЗАМЕТКУ</h3>
          <Input 
             placeholder="Название"
             value={note?.title ?? ""} 
             onChange={(e) => setNote({...note, title: e.target.value})}/>
          <Textarea 
             placeholder="Описание" 
             value={note?.description ?? ""}
             onChange={(e) => setNote({...note, description: e.target.value})}/>
          <Button type="submit">СОЗДАТЬ</Button>
        </form>
    )
}