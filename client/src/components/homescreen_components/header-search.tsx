import { GridItem, Input } from "@chakra-ui/react";

export default function Search(){
    return (
        <GridItem pt={4} pl={2}bg="#D3D3D3" area={'header'}>
            <Input variant='filled' placeholder='Search' />
        </GridItem>
    )
}