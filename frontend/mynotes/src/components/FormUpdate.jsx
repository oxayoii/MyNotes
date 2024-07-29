import { Button, Input, Modal, ModalBody, ModalCloseButton, ModalContent, ModalFooter, ModalHeader, ModalOverlay, Textarea } from "@chakra-ui/react";

export default function FormUpdate ({isOpen, onClose,title, description, setNewTitle, setNewDescription, onConfirm}) {
    const handleTitleChange = (e) => {
        setNewTitle(e.target.value);
    }
    const handleDescriptionChange = (e) => {
        setNewDescription(e.target.value);
    }
    return (
        <Modal isOpen={isOpen} onClose={onClose}>
                <ModalOverlay />
                <ModalContent>
                    <ModalHeader>Редактирование</ModalHeader>
                    <ModalCloseButton />
                    <ModalBody>
                        <Input value={title} onChange={handleTitleChange}/>
                        <Textarea mt={4} value={description} onChange={handleDescriptionChange}/>
                    </ModalBody>
                    <ModalFooter>
                        <Button margin={5} onClick={onConfirm}>Сохранить</Button>
                        <Button onClick={onClose}>Закрыть</Button>
                    </ModalFooter>
                </ModalContent>
        </Modal>
    )
}