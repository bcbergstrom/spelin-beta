import { Box, Button, FormControl, FormLabel, Grid, GridItem, Image, Input, Modal, ModalBody, ModalCloseButton, ModalContent, ModalHeader, ModalOverlay, useDisclosure } from "@chakra-ui/react"
import { useEffect, useState } from "react"

function Main({reviewGame, user}:any) {
    const [reviews, setReviews]:any = useState([{}])
    const { isOpen, onOpen, onClose } = useDisclosure();
    const [bool , setBool] = useState(false)
        useEffect(() => {
        fetch(`/api/reviews/${reviewGame.id}`)
        .then((r) => r.json())
        .then ((data) => {
            setReviews(data)
        })
    }, [reviewGame, bool])


    function logReview(e: any){
        e.preventDefault()
        console.log(user.id)
        fetch('/api/reviews', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({
                GameId: reviewGame.id,
                Rating: e.target[0].value,
                Description: e.target[1].value,
                UserId: user.id
            })
        }
        ).then((r) => r.json())
        .then((data) => {
            if(data.description != undefined){
                setBool(!bool)
            }
        })
    }
    const reviewPage = reviews.map((x:any) => {
        return (
            <GridItem key={x.id} pl={2} bg="white" padding={3} margin={3}>
                <Box maxW={"sm"} bg={"#f9f9f9"} borderWidth={1} borderRadius="lg" overflow="hidden">
                <Box p="6">
              <Box
                mt="1"
                fontWeight="semibold"
                as="h4"
                lineHeight="tight"
                isTruncated
              >
                Review by {x.username}
              </Box>
              <Box>{x.description}</Box>
              <Box as="span" color="gray.600" fontSize="sm">
                Rating: {x.rating} / 5 ⭐
              </Box>
                </Box>
                </Box>
            </GridItem>
            )
    })
    return (
        <GridItem  pl=  {2} bg="#e5e5e5" area={"main"}>
            {reviewGame == null ? <>
            <h1>Please select a game using the <a href="/games">Games</a> tab to set a review!</h1>
            <h2>(current game is {reviewGame.name})</h2>
            </> : <>
            <Image src={reviewGame.imageLink} rounded={"lg"} ml={"25%"} pt={2} boxSize={"40%"} align={"center"}/>
            <GridItem pl={2} bg="#e5e5e5" area={"main"}>
                <Grid
        templateColumns="repeat(3, 0.8fr)"
        templateRows={"repeat(2, 0.8fr)"}
      >
          {reviewPage}
        </Grid>          
                <Button onClick={onOpen}>Submit Review</Button>
                <Modal isOpen={isOpen} onClose={onClose}>
                    <ModalOverlay />
                    <ModalContent>
                    <ModalHeader>Submit Review</ModalHeader>
                    <ModalCloseButton />
                    <ModalBody>
                        <form onSubmit={e =>logReview(e)}>
                        <FormControl>
                            <FormLabel>Rating</FormLabel>
                            <Input type="number" min="1" max="5"/>
                        </FormControl>
                        <FormControl mt={4}>
                            <FormLabel>Description</FormLabel>
                            <Input type="text" />
                        </FormControl>
                        <Button padding={3} mt={4} type="submit">Submit</Button>

                            </form>
                        </ModalBody>
                        </ModalContent>
                </Modal>
                </GridItem>
            </>}
        </GridItem>
    )
}

export default Main