<?php
include "DBconnection.php";

$query = "SELECT products.id, products.name, productTypes.name as type FROM products JOIN productTypes ON products.productTypeID = productTypes.id;";

$result = $mysqli->query($query);

if (!($result = $mysqli->query($query)))
    showerror($mysqli->errno, $mysqli->error);

$emparray = array();
$result = $mysqli->query($query);
while($row = mysqli_fetch_assoc($result)) {
    $emparray[] = $row;
}
echo json_encode($emparray);
?>
