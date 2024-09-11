import { Grid, GridItem } from "@chakra-ui/react"
import LeftNav from "./homescreen_components/left-nav"
import MainScreen from "./homescreen_components/main-screen"
import Breadcrum from "./homescreen_components/breadcrum"
import Search from "./homescreen_components/header-search"

 function Homescreen() {
    return (
<Grid
  templateAreas={`"nav header"
                  "nav main"
                  "nav footer"`}
  gridTemplateRows={'10vh auto 5vh'}
  gridTemplateColumns={'20vh auto'}
  h='100vh'
  overflow={'auto'}
  gap='1'
  color='blackAlpha.700'
  fontWeight='bold'
>
    <Search/>
    <LeftNav/>
    <MainScreen/>
    <Breadcrum/>
</Grid>
    )
}

export default Homescreen