import { Grid } from "@chakra-ui/react";
import LeftNav from "./homescreen_components/left-nav";
import Main from "./review_components/review_screen";
import Breadcrum from "./homescreen_components/breadcrum";

export default function Reviews({reviewGame, user}:any) {
    return (
        <Grid 
        templateAreas={`"nav main" "nav main" "nav footer"`}
        gridTemplateRows={'10vh auto 5vh'}
        gridTemplateColumns={'20vh auto'}
        h='100vh'
        overflow={'auto'}
        gap='1'
        color='blackAlpha.700'
        fontWeight='bold'
        >
            <LeftNav/>
            <Main reviewGame={reviewGame}  user={user}/>
            <Breadcrum/>
        </Grid>    )
}