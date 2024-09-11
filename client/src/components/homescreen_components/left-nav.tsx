import { Avatar, Button, FormControl, FormLabel, Grid, GridItem, Icon, Input, Modal, ModalBody, ModalCloseButton, ModalContent, ModalFooter, ModalHeader, ModalOverlay, useDisclosure } from "@chakra-ui/react";
import { CiLogin, CiLogout } from "react-icons/ci";
export default function LeftNav({setBool} :any) {
    const { isOpen, onOpen, onClose } = useDisclosure();
    function addGame(e : any) {
        e.preventDefault();
        console.log(e.target[2].value)
        fetch("/api/game", {
            method: "POST",
            headers: {
                "Content-Type": "application/json-patch+json",
            },
            body: JSON.stringify({
                name: e.target[0].value,
                description: e.target[1].value,
                price: e.target[2].value
            }),
        })
        .then((r) => r.json())
        .then((data) => {
            alert("Added Game!")
        })
    }
    return (
        <GridItem pl={2} bg={"#D3D3D3"} area='nav'>
            <Grid templateAreas={`"photo"
                "main"
                "favorite"
                "empty"
                "loginout"`} 
                gridTemplateRows={'12vh 5vh 5vh 70vh auto'} gridTemplateColumns={'auto'}>
                    <GridItem area={"photo"} alignSelf={"center"} padding={2} >
                        <a href="/profile"><Avatar color="black" name="Bingus"  /></a>
                    </GridItem>
                    <GridItem area={"main"}>
                        <a href="/">Home</a>
                    </GridItem>
                    <GridItem area={"favorite"}>
                        <a href="/games">Games</a>
                    </GridItem>
                    <GridItem area={"empty"}>
                        <Button colorScheme="teal" onClick={onOpen} variant="solid">Add Game</Button>
                    </GridItem>
                    <GridItem area={"loginout"}  >
                        <Icon as={CiLogin} />
                        <a  href="/login">  Login</a>
                    </GridItem>
            </Grid>
            <Modal isOpen={isOpen} onClose={onClose}>
                <ModalOverlay />
                <ModalContent>
                    <ModalCloseButton />
                    <ModalHeader>Add New Game</ModalHeader>
                    <ModalBody>
                    <form onSubmit={(e) => {addGame(e) }}>
                        <FormControl>
                            <FormLabel>Name of Game</FormLabel>
                            <Input type="text" placeholder="Name" />
                            <FormLabel>Description</FormLabel>
                            <Input type="text" placeholder="Description" />
                            <FormLabel>Price</FormLabel>
                            <Input type="number" placeholder="Enter your password" />
                        </FormControl>
                        <Button  type="submit" colorScheme="blue" padding={5} margin={5}>Add</Button>
                    </form>

                    </ModalBody>
                    <ModalFooter>
                        <Button colorScheme='blue' mr={3} onClick={onClose}>
                            Close
                        </Button>
                    </ModalFooter>
                </ModalContent>
            </Modal>
        </GridItem>
            );
}