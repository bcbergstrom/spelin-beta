import { Button, FormControl, FormLabel, Grid, GridItem, Input, Link, Modal, ModalBody, ModalCloseButton, ModalContent, ModalFooter, ModalHeader, ModalOverlay, useDisclosure } from "@chakra-ui/react";
import { useNavigate } from "react-router";

export default function Login({setUser, user} : any) {

    const {isOpen, onOpen, onClose} = useDisclosure();
    const navigate = useNavigate();
    function login(e : any) {
        e.preventDefault();
        fetch("/api/user/login", {
            method: "POST",
            headers: {
                "Content-Type": "application/json",
            },
            body: JSON.stringify({
                Email: e.target[0].value,
                Password: e.target[1].value
            }),
        })
        .then((r) => r.json())
        .then((data) => {
            if (data.error) {
                alert(data.error)
                setUser(e.target[0].value)
            } else {
                setUser(e.target[0].value)
            }
            navigate("/")
        })
        .catch((err) => alert(err));
    }


    function register(e : any) {
        e.preventDefault();
        fetch("/api/user/register", {
            method: "POST",
            headers: {
                "Content-Type": "application/json",
            },
            body: JSON.stringify({
                Name: e.target[0].value,
                Email: e.target[1].value,
                Password: e.target[2].value
            }),
        })
        .then((r) => r.json())
        .then((data) => {
            if (data.error) {
                alert(data.error)
                setUser(e.target[0].value)
            } else {
                setUser(e.target[0].value)
            }
            navigate("/")
    })
    .catch((err) => alert(err));
}



    return (
        <>
        <Modal isOpen={isOpen} onClose={onClose}>
            <ModalOverlay />
            <ModalContent>
                <ModalHeader>Register</ModalHeader>
                <ModalCloseButton />
                <ModalBody>
                    <form>
                        <FormControl>
                            <FormLabel>Name</FormLabel>
                            <Input type="text" placeholder="Enter your name" />
                            <FormLabel>Email address</FormLabel>
                            <Input type="email" placeholder="Enter your email" />
                            <FormLabel>Password</FormLabel>
                            <Input type="password" placeholder="Enter your password" />
                        </FormControl>
                        <Button onSubmit={(e) => {register(e) }} type="submit" colorScheme="blue" padding={5} margin={5}>Register</Button>
                    </form>
                </ModalBody>
                <ModalFooter>
                    <Button onClick={onClose}>Close</Button>
                </ModalFooter>
            </ModalContent>
        </Modal>

        <Grid templateColumns="repeat(3, 0.8fr)" templateRows={"repeat(2, 0.8fr)"}
        >
            <GridItem></GridItem>
            <GridItem bg={"#f9f9f9"} fontSize={50} textAlign={"center"} p={4} >
                <h1>Login</h1>
            </GridItem>
            <GridItem></GridItem>
            <GridItem ></GridItem>
            <GridItem bg={"#f9f9f9"}   textAlign={"center"} p={4}>
                <form onSubmit={(e) => {login(e) }}>
                <FormControl>
                    <FormLabel>Email address</FormLabel>
                    <Input type="email" placeholder="Enter your email" />
                    <FormLabel>Password</FormLabel>
                    <Input type="password" placeholder="Enter your password" />
                </FormControl>
                <Button type="submit" colorScheme="blue" padding={5} margin={5}>Login</Button>
                </form>
                <Button  onClick={onOpen} colorScheme="gray" padding={5} margin={5} >Register</Button>

            </GridItem>
        </Grid>
        </>
    )
}