import { Box, Button, Editable, EditablePreview, EditableTextarea, FormControl, FormLabel, Grid, GridItem, Image, Input, Modal, ModalBody, ModalCloseButton, ModalContent, ModalFooter, ModalHeader, ModalOverlay, useDisclosure } from "@chakra-ui/react";
import { useEffect, useState } from "react";

export default function GamesScreen() {
  const [games, setGames] = useState([{}]);
  const [bool , setBool] = useState(false)
  const { isOpen, onOpen, onClose } = useDisclosure();
  useEffect(() => {
    fetch("/api/game")
      .then((r) => r.json())
      .then((data) => {
        setGames(data);
        setBool(false);
      });
  }, [bool]);

  function editGame(e: any, id: any) {
    e.preventDefault();
    fetch(`/api/game/${id}`, {
      method: "PUT",
      headers: {
        "Content-Type": "application/json-patch+json",
      },
      body: JSON.stringify({
        Name: e.target[0].value,
        Description: e.target[1].value,
        ImageLink: e.target[2].value,
        Price: parseInt(e.target[3].value)
      }),
    })
    .then((r) => setBool(!bool))
  }
  function deleteGame(id: any) {
    fetch(`/api/game/${id}`, {
      method: "DELETE"
    })
    .then(r => setBool(!bool))
    console.log("bool")
    setBool(!bool)
  }


  const element = games.map((game: any) => {
    return (
        <GridItem key={game.id} pl={2} bg="white" padding={3} margin={3}>
          <Box maxW={"sm"} bg={"#f9f9f9"} borderWidth={1} borderRadius="lg" overflow="hidden">
            <Image key={game.id} src={game.imageLink} alt={game.name} fit={"cover"}/>
            <Box p="6">
              <Box
                mt="1"
                fontWeight="semibold"
                as="h4"
                lineHeight="tight"
                isTruncated
              >
                {game.name}
              </Box>
              <Box>{game.description}</Box>
              <Button colorScheme="blue" onClick={onOpen}>Edit Menu</Button>
              <Modal isOpen={isOpen} onClose={onClose}>
                <ModalOverlay />
                <ModalContent>
                  <ModalHeader>Edit</ModalHeader>
                  <ModalCloseButton />
                  <ModalBody>
                  <form onSubmit={(e) => {editGame(e, game.id) }}>
                        <FormControl>
                            <FormLabel>Name of Game</FormLabel>
                            <Input type="text" placeholder="Name" />
                            <FormLabel>Description</FormLabel>
                            <Input type="text" placeholder="Description" />
                            <FormLabel>Image Link</FormLabel>
                            <Input type="text" placeholder="Description" />
                            <FormLabel>Price</FormLabel>
                            <Input type="number" placeholder="Enter your password" />
                        </FormControl>
                        <Button type="submit" colorScheme="blue" padding={5} margin={5}>Edit</Button>
                    </form >
                  </ModalBody>
                  <ModalFooter>
                    <Button onClick={onClose}>Close</Button>
                    <Button onClick={() => {deleteGame(game.id)}}>Delete</Button>
                  </ModalFooter>
                </ModalContent>
              </Modal>
            </Box>
          </Box>
        </GridItem>
    )})

  return (
    <GridItem pl={2} bg="#e5e5e5" area={"main"}>
      <Grid
        templateColumns="repeat(3, 0.8fr)"
        templateRows={"repeat(2, 0.8fr)"}
      >
        {element}
      </Grid>
    </GridItem>
  );
}
