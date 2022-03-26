CREATE VIEW allItems AS
SELECT i.item_name, i.count, i.value, u.unit_name, t.type_name  FROM item i
JOIN unit u
ON u.id = i.unit_id
JOIN item_type t
ON t.id = i.type_id;
