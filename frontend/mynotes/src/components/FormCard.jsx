import { Button, ButtonGroup, Card, CardBody, CardFooter, CardHeader, Divider, Heading, Text } from "@chakra-ui/react"
import moment from "moment/moment"
import { useState } from "react"
import FormUpdate from "./FormUpdate"
import { updateNote, deleteNote} from "../service/notes"

export default function FormCard ({id, title, description, createAt, onUpdate}){
  const [isOpen, setIsOpen] = useState(false)
  const [newTitle, setNewTitle] = useState(title);
  const [newDescription, setNewDescription] = useState(description);

  const handleOpenModal = () => {
    setNewTitle(title)
    setNewDescription(description)
    setIsOpen(true)
  }
  const handleCloseModal = () => {
    setIsOpen(false)
  }

  const handleUpdateNote = async () => {
    
    await updateNote(id, {title: newTitle, description: newDescription});
    console.log('Current ID:', id);
    onUpdate();
    setIsOpen(false);
  }
  const handleDeleteNotes = async () => {
    await deleteNote(id);
    onUpdate();
  }
    return (
      <div className='card'>
      <Card>
        <CardHeader>
           <Heading>{title}</Heading>
         </CardHeader>
         <Divider/>
         <CardBody>
           <Text>{description}</Text>
         </CardBody>
           <Divider/>
         <CardFooter>{moment(createAt).format("DD/MM/YYYY h:mm")}</CardFooter>
         <ButtonGroup>
           <Button onClick={handleOpenModal}>Редактировать</Button>
           <FormUpdate 
               isOpen={isOpen}
               onClose={handleCloseModal} 
               title={newTitle} 
               description={newDescription} 
               setNewTitle={setNewTitle} 
               setNewDescription={setNewDescription} 
               onConfirm={handleUpdateNote}/>
           <Button onClick={handleDeleteNotes}>Удалить</Button>
         </ButtonGroup>
     </Card>
     </div>
    )
}