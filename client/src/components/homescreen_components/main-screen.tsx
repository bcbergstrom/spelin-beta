import { Grid, GridItem, Image, Link } from "@chakra-ui/react";

export default function Screen() {
    return (
        <GridItem  pl=  {2} bg="#e5e5e5" area={"main"}>
            <Grid templateColumns="repeat(3, 0.8fr)" templateRows={"repeat(2, 0.8fr)"}
            >
                <GridItem></GridItem>
                <GridItem bg={"white"} textAlign={"center"} p={4} rounded={"lg"}>
                    Spelin, a game Tracker
                    <Image src="https://plus.unsplash.com/premium_photo-1677870728087-2257ce93bfe9?w=900&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8NXx8Z2FtZXxlbnwwfHwwfHx8MA%3D%3D" rounded={"lg"} ></Image>
                </GridItem>
                <GridItem></GridItem>
                <GridItem ></GridItem>
                <GridItem bg={"white"} rounded={"lg"} textAlign={"center"} p={4}>
                    <p>Spelin is an all-in-one game tracker, game review, and game reccomendation system. </p>
                    <p>It is designed with ease of use in mind. Need to find a game? Search it! Need to add a game, add it!</p>
                    <Link href="/credits" color="blue"> Learn More/Credits</Link>
                </GridItem>



            </Grid>
        </GridItem>
    )
}