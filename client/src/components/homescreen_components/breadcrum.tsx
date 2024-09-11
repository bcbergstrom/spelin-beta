import { Breadcrumb, BreadcrumbItem, BreadcrumbLink, GridItem, Link } from "@chakra-ui/react";

export default function Breadcrum() {
  return (
    <GridItem pl={2} bg="#D3D3D3" area={"footer"}>
      <Breadcrumb>
        <BreadcrumbItem>
          <BreadcrumbLink href="#">Home</BreadcrumbLink>
        </BreadcrumbItem>
      </Breadcrumb>
    </GridItem>
  );
}
