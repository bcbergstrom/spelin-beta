import { Grid } from "@chakra-ui/react";
import LeftNav from "./homescreen_components/left-nav";
import GamesScreen from "./games_components/GamesScreen";
import Breadcrum from "./homescreen_components/breadcrum";

export default function Games({reviewGame, setReviewGame}:any) {
  return (
    <Grid
      templateAreas={`"nav main"
                  "nav main"
                  "nav footer"`}
      gridTemplateRows={"auto auto  5vh"}
      gridTemplateColumns={"20vh auto"}
      h="100vh"
      overflow={"auto"}
      gap="1"
      color="blackAlpha.700"
      fontWeight="bold"
    >
        <LeftNav/>
        <GamesScreen setReviewGame={setReviewGame}/>
        <Breadcrum/>
    </Grid>
  );
}
