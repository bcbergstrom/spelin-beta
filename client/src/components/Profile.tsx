import { Grid } from "@chakra-ui/react";
import LeftNav from "./homescreen_components/left-nav";
import Breadcrum from "./homescreen_components/breadcrum";
import MainScreen from "./homescreen_components/main-screen";
import Search from "./homescreen_components/header-search";
import Main from "./profile_components/profile_main";

function Profile() {
    return (
    <Grid 
    templateAreas={`"nav header" "nav main" "nav footer"`}
    gridTemplateRows={'10vh auto 5vh'}
    gridTemplateColumns={'20vh auto'}
    h='100vh'
    overflow={'auto'}
    gap='1'
    color='blackAlpha.700'
    fontWeight='bold'
    >
        <LeftNav/>
        <Main />
        <Breadcrum/>
        <Search/>
    </Grid>
    )
}
export default Profile