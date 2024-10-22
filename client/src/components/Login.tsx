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
                Name: e.target[0].value,
                Password: e.target[1].value
            }),
        })
        .then((r) => r.json())
        .then((data) => {
            if (data.status == 404) {
                alert("User not found")
            } else if (data.name != undefined && data.password != undefined) {
                setUser(data)
                navigate("/games")
            } else{
                alert("Invalid Sign-In")
            }
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
        .then((r) => {
            console.log(r)
            return r.json()

        })
        .then((data) => {
            if (data.status == 404) {
                alert("Registration Failed - Password is too short")
            }
            else if (data.errors != undefined) {
                alert("Registration Failed - " + data.errors[0].description)
            }
            else {
                setUser(data)
                navigate("/games")
            }
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
                    <form onSubmit={(e) => {register(e) }}>
                        <FormControl>
                            <FormLabel>Name</FormLabel>
                            <Input type="text" placeholder="Enter your name" />
                            <FormLabel>Email address</FormLabel>
                            <Input type="email" placeholder="Enter your email" />
                            <FormLabel>Password</FormLabel>
                            <Input type="password" placeholder="Enter your password" />
                        </FormControl>
                        <Button  type="submit" colorScheme="blue" padding={5} margin={5}>Register</Button>
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
                    <FormLabel>User Name</FormLabel>
                    <Input type="text" placeholder="Enter your Username" />
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